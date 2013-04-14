using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Net;
using System.Web.Services;


// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    /**
 * Provides movie name
 *
 * @param       name_    (string) movie name you looking for 
 * @param       movie_id_   (string) movie id if you know else sen empty string
 * @param       year       (string) year of movie if you know else sen empty string
 *
 * @return              json object 
 */
    public string getMovie(string name_, string movie_id_, string year_) 
    {
        string output;
        string name = name_;
        string movie_id = movie_id_;
        string year = year_;
        using (WebClient client = new WebClient())
        {
            string input = "http://www.omdbapi.com/?t=" + name + "&y=" + year;
            output = client.DownloadString(input);


            

            //JsonValue value = JsonValue.Parse(output);
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, string>>(output);
            return (jss.Serialize(dict));
        }  
    }

    /**
* Provides name of movie. This is very useful for autocomplete
*
* @param       name_    (string) movie name you looking for 
* @return              json object 
*/

    public string getMovieList(string name_)
    {
        string output;
        string name = name_;
        
        using (WebClient client = new WebClient())
        {
            string input = "http://www.omdbapi.com/?s=" + name;
            output = client.DownloadString(input);
            //JsonValue value = JsonValue.Parse(output);
            var jss = new JavaScriptSerializer();
            var dict = jss.Deserialize<Dictionary<string, dynamic>>(output);
            return (jss.Serialize(dict));
        }
    }

}
