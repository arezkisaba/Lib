using System.Collections.Generic;

namespace Lib.Core
{
	public interface ISystemDisplayService
	{
		List<DisplayModel> GetAll();

		DisplayModel GetCurrent();

		DisplayModel GetLowerDisplay();

        DisplayModel GetHigherDisplay();

        void SetCurrent(DisplayModel display);
	}
}