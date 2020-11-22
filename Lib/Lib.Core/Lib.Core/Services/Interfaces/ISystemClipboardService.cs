namespace Lib.Core
{
	public interface ISystemClipboardService
    {
        string GetText();

        void SetText(string text);
    }
}