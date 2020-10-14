using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MiLight.Lib.Enums;

#if NETFX_CORE || WINDOWS_PHONE
using Windows.Networking.Sockets;
using Windows.Networking;
using Windows.Storage.Streams;
#else
#endif

namespace MiLight.Lib.Models
{
    public class MiLightClient
    {
        private static readonly object Lock = new object();
        protected StringBuilder ReceiveBuffer = new StringBuilder();
        private readonly string _outHost;
        private readonly int _outPort;
        internal bool Admin = false;
#if NETFX_CORE || WINDOWS_PHONE
        private DatagramSocket _socket;
        private DataWriter _writer;
#else
        protected UdpClient Client;
        private IPEndPoint _outIp;
        internal IPEndPoint InIp;
#endif

        public MiLightClient(string outHost = "10.10.100.254", int outPort = 8899)
        {
            _outHost = outHost;
            _outPort = outPort;
        }

        public async Task<string> ReceiveDataAsync()
        {
#if NETFX_CORE || WINDOWS_PHONE
#else
            for (var i = 0; i < 3; i++)
            {
                if (Client.Available > 0)
                {
                    ReceiveBuffer.AppendLine(Encoding.UTF8.GetString(Client.Receive(ref InIp)));
                    break;
                }

                await Task.Delay(500);
            }
#endif
            var s = ReceiveBuffer.ToString();
            ReceiveBuffer.Clear();
            await Task.Run(() => { });
            return s;
        }

        public async Task SendDataAsync(string data, int delay = 100)
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            await SendDataAsync(dataBytes, delay);
        }

        public async Task SendDataAsync(byte[] data, int delay = 100)
        {
#if NETFX_CORE || WINDOWS_PHONE
            if (_socket == null)
            {
                lock (_lock)
                {
                    if (_socket == null)
                        _socket = new DatagramSocket();
                }
                await _socket.ConnectAsync(new HostName(_outHost), _outService);
                if (_admin)
                    _socket.MessageReceived += _socket_MessageReceived;
                _writer = new DataWriter(_socket.OutputStream);
            }
            _writer.WriteBytes(data);
            await _writer.StoreAsync();
#else
            if (Client == null)
            {
                lock (Lock)
                {
                    if (Client == null)
                    {
                        Client = new UdpClient();
                    }
                }

                _outIp = new IPEndPoint(IPAddress.Parse(_outHost), _outPort);
                Client.Client.MulticastLoopback = false;
                Client.EnableBroadcast = true;

                if (Admin)
                {
                    InIp = new IPEndPoint(IPAddress.Parse("0.0.0.0"), _outPort);
                    Client.Client.ReceiveTimeout = 3000;
                    Client.Client.Bind(InIp);
                }
            }

            Client.Send(data, data.Length, _outIp);
#endif
            await Task.Delay(delay);
        }

#if NETFX_CORE || WINDOWS_PHONE
        private void _socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            var reader = args.GetDataReader();
            _receiveBuffer.AppendLine(reader.ReadString(reader.UnconsumedBufferLength));
        }
#endif

        public void Close()
        {
#if NETFX_CORE || WINDOWS_PHONE
            _socket.Dispose();
#else
            if (Client != null)
            {
                Client.Close();
            }
#endif
        }

        #region LED Commands

        public async Task RGBWSetBrightnessAsync(MiLightGroups group, byte level)
        {
            if (level < 0x02)
            {
                level = 0x02;
            }
            else if (level > 0x27)
            {
                level = 0x27;
            }

            var cmd = (byte[]) MiLightCommands.RGBWBrightness.Clone();
            cmd[1] = level;

            await RGBWSwitchOnAsync(group);
            await DelayAsync();
            await SendCommandAsync(cmd);
        }

        public async Task RGBWSetColorAsync(MiLightGroups group, byte color)
        {
            var cmd = (byte[]) MiLightCommands.RGBWColor.Clone();
            cmd[1] = color;

            await RGBWSwitchOnAsync(group);
            await DelayAsync();
            await SendCommandAsync(cmd);
        }

        public async Task RGBWSetDiscoModeAsync(MiLightGroups group)
        {
            await RGBWSwitchOnAsync(group);
            await DelayAsync();
            await SendCommandAsync(MiLightCommands.RGBWDiscoMode);
        }

        public async Task RGBWSetNightModeAsync(MiLightGroups group)
        {
            byte[] cmd;
            switch (group)
            {
                case MiLightGroups.One:
                    cmd = MiLightCommands.RGBWGroup1AllNight;
                    break;
                case MiLightGroups.Two:
                    cmd = MiLightCommands.RGBWGroup2AllNight;
                    break;
                case MiLightGroups.Three:
                    cmd = MiLightCommands.RGBWGroup3AllNight;
                    break;
                case MiLightGroups.Four:
                    cmd = MiLightCommands.RGBWGroup4AllNight;
                    break;
                default:
                    cmd = MiLightCommands.RGBWOff;
                    break;
            }

            await RGBWSwitchOffAsync(group);
            await DelayAsync();
            await SendCommandAsync(cmd);
        }

        public async Task RGBWSetWhiteModeAsync(MiLightGroups group)
        {
            byte[] cmd;
            switch (group)
            {
                case MiLightGroups.One:
                    cmd = MiLightCommands.SetColorToWhiteGroup1;
                    break;
                case MiLightGroups.Two:
                    cmd = MiLightCommands.SetColorToWhiteGroup2;
                    break;
                case MiLightGroups.Three:
                    cmd = MiLightCommands.SetColorToWhiteGroup3;
                    break;
                case MiLightGroups.Four:
                    cmd = MiLightCommands.SetColorToWhiteGroup4;
                    break;
                default:
                    cmd = MiLightCommands.SetColorToWhite;
                    break;
            }

            await RGBWSwitchOnAsync(group);
            await DelayAsync();
            await SendCommandAsync(cmd);
        }

        public async Task RGBWSwitchOffAsync(MiLightGroups group)
        {
            byte[] cmd;
            switch (group)
            {
                case MiLightGroups.One:
                    cmd = MiLightCommands.RGBWGroup1AllOff;
                    break;
                case MiLightGroups.Two:
                    cmd = MiLightCommands.RGBWGroup2AllOff;
                    break;
                case MiLightGroups.Three:
                    cmd = MiLightCommands.RGBWGroup3AllOff;
                    break;
                case MiLightGroups.Four:
                    cmd = MiLightCommands.RGBWGroup4AllOff;
                    break;
                default:
                    cmd = MiLightCommands.RGBWOff;
                    break;
            }
            await SendCommandAsync(cmd);
        }

        public async Task RGBWSwitchOnAsync(MiLightGroups group)
        {
            byte[] cmd;
            switch (group)
            {
                case MiLightGroups.One:
                    cmd = MiLightCommands.RGBWGroup1AllOn;
                    break;
                case MiLightGroups.Two:
                    cmd = MiLightCommands.RGBWGroup2AllOn;
                    break;
                case MiLightGroups.Three:
                    cmd = MiLightCommands.RGBWGroup3AllOn;
                    break;
                case MiLightGroups.Four:
                    cmd = MiLightCommands.RGBWGroup4AllOn;
                    break;
                default:
                    cmd = MiLightCommands.RGBWOn;
                    break;
            }

            await SendCommandAsync(cmd);
        }

        private async Task SendCommandAsync(byte[] buffer)
        {
            await SendDataAsync(buffer, buffer.Length);
        }

        public async Task DelayAsync(int millisecondsTimeout = 101)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(millisecondsTimeout));
        }

        #endregion
    }
}