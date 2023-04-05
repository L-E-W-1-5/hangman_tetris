using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;
using static System.IO.Path;

namespace WPF.Backend
{
    public static class Utility
    {

        private const string ProfileFile = "profiles.txt";


        public static void CreateProfile(ProfileModel profile)     
        {
            string path = Path.Combine(CurrentDirectory, ProfileFile);

            int currentId = 0;

            List<ProfileModel> profiles = new();         

            profiles = LoadFile().ConvertToProfileModels();

            if (profiles.Count > 0)
            {
                currentId = profiles.OrderByDescending(x => x.Id).First().Id + 1;
            }

            profile.Id = currentId;

            profiles.Add(profile);

            profiles.SaveToFile(path);

        }


        public static List<string> LoadFile()
        {
            if (!File.Exists(ProfileFile))
            {
                return new List<string>();
            }

            return File.ReadAllLines(ProfileFile).ToList();
        }


        public static void SaveToFile(this List<ProfileModel> profiles, string path)
        {
            List<string> lines = new();

            foreach (ProfileModel p in profiles)
            {
                lines.Add($"{p.Id},{p.UserName},{p.HangmanScore},{p.TetrisScore}");
            }

            File.WriteAllLines(path, lines);
        }


        public static List<ProfileModel> ConvertToProfileModels(this List<string> lines)
        {
            List<ProfileModel> profiles = new();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                ProfileModel p = new();     // TODO - Need to add the column for Tetris scores.. May need to delete the profile
                                            // file and start again? Would like to try to work it out properly though.
                                            // just need the profiles without a score to be saved with a zero for tetris.
                p.Id = int.Parse(cols[0]);
                p.UserName = cols[1];

                //if (cols[2].Length == 0)
                //{
                //    p.HangmanScore = 0;
                //}
                //else
                //{
                    p.HangmanScore = int.Parse(cols[2]);
               // }

                //if (cols[3].Length == 0)
                //{
                //    p.TetrisScore = 0;
                //}
                //else
                //{
                    p.TetrisScore = int.Parse(cols[3]);
               // }
                

                profiles.Add(p);
            }
            return profiles;
        }


        public static List<ProfileModel> GetAllProfiles()
        {
            return LoadFile().ConvertToProfileModels();
        }


        public static void AddScoreToProfile(ProfileModel model)
        {
            string path = Path.Combine(CurrentDirectory, ProfileFile);

            List<string> lines = File.ReadAllLines(ProfileFile).ToList();

            List<ProfileModel> profiles = lines.ConvertToProfileModels();

            var winningProfile = profiles.Where(x => x.Id == model.Id).First();

            winningProfile.HangmanScore += 1;

            profiles.SaveToFile(path);

        }


        public static bool NameExists(ProfileModel model)
        {
            List<ProfileModel> existing = new();

            existing = LoadFile().ConvertToProfileModels();

            if (existing.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (ProfileModel profile in existing)
                {
                    if (profile.UserName == model.UserName) return true;
                }
            }

            return false;
        }


        public static string GetWord()
        {
            
            string wordPath = Path.Combine(CurrentDirectory, "words.txt");

            Random r = new();

            string[] lines = File.ReadAllLines(wordPath);

            int idx;

            do
            {
                idx = r.Next(lines.Length);
            }
            while (lines[idx].Length > 6);

            return lines[idx];          
        }


        public static void AddTetrisScoreToProfile(ProfileModel model, int score)
        {
            string path = Path.Combine(CurrentDirectory, ProfileFile);

            List<ProfileModel> profiles = LoadFile().ConvertToProfileModels();

            var winningModel = profiles.Where(x => x.Id == model.Id).First();

            if (score > winningModel.TetrisScore)
            {
                winningModel.TetrisScore = score;

                profiles.SaveToFile(path);
            }
            

            // TODO - Add tetris score here, if higher than current etc  
        }
      
    }
}
