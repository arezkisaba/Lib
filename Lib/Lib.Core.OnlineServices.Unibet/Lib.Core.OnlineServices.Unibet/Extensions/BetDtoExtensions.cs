namespace Lib.Core.OnlineServices.Unibet
{
    public static class BetDtoExtensions
	{
		public static BetDto FromQueryResponse(this BetDto dto, GetBetsResponse.Betleg queryResult)
		{
			if (queryResult == null)
			{
				return dto;
			}

            return new BetDto
            {
                Id = queryResult.selectionId,
                Title = queryResult.eventName
            };
		}
	}
}