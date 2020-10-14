using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Core.OnlineServices.Unibet
{
    public interface IUnibetService
    {
        Task ClearBetsAsync();

        Task<List<GetBetsResponse.Betleg>> GetBetsAsync();

        Task<AddBetResponse> AddBetAsync(AddBetBody body);

        Task<PlaceSimpleBetsResponse> PlaceSimpleBetsAsync(PlaceSimpleBetsBody body);

        Task<PlaceMultipleBetsResponse> PlaceMultipleBetsAsync(PlaceMultipleBetsBody body);

        Task CancelPlaceBetsAsync(CancelPlaceBetsBody body);

        Task<ConfirmBetsResponse> ConfirmBetsAsync(ConfirmBetsBody body);
    }
}
