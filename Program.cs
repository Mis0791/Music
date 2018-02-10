using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //There is only one artist in this collection from Mount Vernon, what is their name and age?

            IEnumerable<Artist> theOne = Artists.Where( a => a.Hometown == "Mount Vernon");

            //Who is the youngest artist in our collection of artists?

            IEnumerable<Artist> theOnly = Artists.OrderBy( b => b.Age);  

            //Display all artists with 'William' somewhere in their real name

            IEnumerable<Artist> allW = Artists.Where( c => c.ArtistName == "William");

            //Display all groups with names less than 8 characters in length 

            IEnumerable<Group> allGroups = Groups.Where( d => d.GroupName.Length < 8).OrderBy( d => d.GroupName.Length);

            //Display the 3 oldest artists from Atlanta

            IEnumerable<Artist> oldestArtists = Artists.Where( e => e.Hometown == "Atlanta").OrderByDescending( e => e.Age).Take(3);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            IEnumerable<Group> notYork = Groups.Join(Artists.Where( f => f.Hometown != "New York City"), group => group.Id, f => f.GroupId, (group, f) => {return group;}).Distinct();

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

            IEnumerable<Artist> notWu = Artists.Join(Groups.Where( group => group.GroupName == "Wu-Tang Clan"), artist => artist.GroupId, group => group.Id, (artist, group) => {return artist;});


            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================


        }
    }
}
