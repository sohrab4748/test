using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class videos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Videos For Online Distribution Fitting and Calculator";
        try
        {
            var playListKey = "PLaT4Cfntnc9juIVeIb74YOELbJZGReS1Z";
            var apiKey = "AIzaSyCIF1RrEDAkf22Lb206m5EHJ6gfDmcqMJM";
            var url = string.Format("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&playlistId={0}&key={1}", playListKey, apiKey);
            var req = HttpGet(url);
            var jo = JObject.Parse(req);
            var it = jo.SelectToken("items");
            var len = it.Count();
            for (int i = 0; i < len; i++)
            {
                var it1 = it[i].SelectToken("snippet");
                var t = it1.SelectToken("title").ToString();
                var d = it1.SelectToken("description").ToString();
                var it2 = it1.SelectToken("thumbnails");
                var it21 = it2.SelectToken("high");
                var u = it21.SelectToken("url").ToString();
                var it3 = it1.SelectToken("resourceId");
                var v = it3.SelectToken("videoId").ToString();
                // variables
                string Template = lblTemplate.Text;
                // replace placeholders
                Template = Template.Replace("{VideoId}", v);
                Template = Template.Replace("{Title}", t);
                Template = Template.Replace("{Url}", string.Format("https://www.youtube.com/watch?v={0}", v));
                Template = Template.Replace("{Image}", u);
                Template = Template.Replace("{Alt}", t);
                Template = Template.Replace("{Description}", d);
                Template = Template.Replace("{ToolTip}", HttpUtility.HtmlEncode(t));
                // add to videos panel
                pnlVideos.Controls.Add(new LiteralControl(Template));
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }




    protected string get(string url)
    {
        try
        {
            string rt;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();
            Console.WriteLine(rt);
            reader.Close();
            response.Close();
            return rt;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
    public string HttpGet(string URI)
    {
        WebClient client = new WebClient();
        // Add a user agent header in case the 
        // requested URI contains a query.
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        Stream data = client.OpenRead(URI);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return s;
    }
}