using System.Collections.Generic;

namespace Lib.Core
{
	public interface IDisplayService
	{
		List<DisplayModel> GetAll();

		DisplayModel GetCurrent();

		DisplayModel GetLowerDisplay();

        DisplayModel GetHigherDisplay();

        void SetCurrent(DisplayModel display);
	}
}