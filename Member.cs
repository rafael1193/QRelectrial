/* 
 * This file is part of QRelectrial
 * Copyright (C) 2013 Rafael Bailón-Ruiz
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QRelectrial
{
    struct Member
    {
        public uint ID
        {
            get { return id; }
            set { id = value; }
        }

        public string GivenName
        {
            get { return givenName; }
            set { givenName = value; }
        }

        public string FamilyName
        {
            get { return familyName; }
            set { familyName = value; }
        }

        private uint id;
        private string givenName;
        private string familyName;

        public Member(uint id, string givenName, string familyName)
        {
            this.id = id;
            this.givenName = givenName;
            this.familyName = familyName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Member)
            {
                Member m = (Member)obj;
                if (m.ID == id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return id.ToString() + " " + FamilyName + ", " + GivenName;
        }
    }
}
