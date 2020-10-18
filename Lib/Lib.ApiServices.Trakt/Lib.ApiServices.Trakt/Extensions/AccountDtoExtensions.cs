using System;

namespace Lib.ApiServices.Trakt
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
				Id = Convert.ToString(response.user.ids.slug),
				Name = response.user.name,
				Username = response.user.username
			};
		}
	}
}
