using System.ComponentModel.DataAnnotations;
using AdoDotNet.Utility;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AdoDotNet.Models;

public class HomeModel
{
     
    public int Id { get; set; }
    [Required]  
    public string Name { get; set; }
    [Required]  
    public string Address { get; set; }
    [Required]  
    public string Age { get; set; }
    [Required]  
    public  string Job { get; set; }
    
    public HomeModel()
    {
     
    }

    internal void InsertData(string connectionString )
    {
       
        List<(string Key, object value)> data = new List<(string Key, object value)>();
        data.Add(("@Name", Name));
        data.Add(("@Address", Address));
        data.Add(("@Age",Age));
        data.Add(("@job", Job));
        var command = @"insert into Parson (Name,Address,Age, Job) values (@Name, @Add, @Age, @Job)";
        var dataUtility = new DataUtility(connectionString);
        dataUtility.ExecuteCommand(command, data);
    }
      
}