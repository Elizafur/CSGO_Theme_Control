//    This file is part of CSGO Theme Control.
//    Copyright (C) 2015  Elijah Furland      
//
//    CSGO Theme Control is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    CSGO Theme Control is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with CSGO Theme Control.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Linq;

namespace CSGO_Theme_Control.Base_Classes.UserSettingsEnum
{
    public class UserSettingsContainer
    {
        private readonly List<UserSettings.Options> OptList = new List<UserSettings.Options>(); 

        public UserSettingsContainer(params UserSettings.Options[] uOptions)
        {
            foreach (var option in uOptions)
                OptList.Add(option);

            //Distinct used to remove all duplicate values.
            OptList = OptList.Distinct().ToList();
        }

        public void Add(UserSettings.Options o)
        {
            if (!OptList.Contains(o))
                OptList.Add(o);
        }

        public void Remove(UserSettings.Options o)
        {
            OptList.Remove(o);
        }

        public UserSettings.Options[] GetOptions()
        {
            return OptList.ToArray();
        }
    }
}
