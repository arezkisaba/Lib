using System;

namespace Lib.ApiServices.TheMovieDatabase
{
    public static class AccountDtoExtensions
	{
		public static AccountDto FromQueryResponse(this AccountDto dto, GetAccountResponse response)
		{
			if (response == null)
			{
				return dto;
			}

			return new AccountDto
			{
				Id = Convert.ToString(response.id),
				Name = response.name,
				Username = response.username
			};
		}
	}
}
