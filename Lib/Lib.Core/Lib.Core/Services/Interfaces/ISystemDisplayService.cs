using System.Collections.Generic;

namespace Lib.Core
{
	public interface ISystemDisplayService
	{
		List<SystemDisplayModel> GetAll();

		SystemDisplayModel GetCurrent();

		SystemDisplayModel GetLowerDisplay();

        SystemDisplayModel GetHigherDisplay();

        void SetCurrent(SystemDisplayModel display);
	}
}