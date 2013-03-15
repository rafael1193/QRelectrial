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
