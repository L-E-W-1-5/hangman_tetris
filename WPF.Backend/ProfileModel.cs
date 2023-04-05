using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Backend
{
    public class ProfileModel
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public int HangmanScore { get; set; } = 0;

        public int TetrisScore { get; set; } = 0;


        //public ProfileModel(string name)
        //{
        //    UserName = name;
        //}
        public override string ToString()
        {
            return $"{UserName}";
        }
    }
}
