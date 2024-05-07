using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Color_Coder.Lib
{
  public class ColorData
  {
    public string Color { get; set; }
    public string HexCode { get; set; }
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public int Alpha { get; set; }
    public List<int> ColorProducts { get; set; }
    public List<string> PossibleCombonations { get; set; }
    public ColorData(List<int> products)
    {
      this.ColorProducts = products;
      this.PossibleCombonations = new List<string>();
      GenerateAllPossibleCombonations();
    }


    private void GenerateAllPossibleCombonations() 
    {

      foreach (var p in this.ColorProducts) 
      {
        var combonations = GenerateCombonationsPerProduct(p);
        this.PossibleCombonations.AddRange(combonations);
      }
    }

    private static List<string> GenerateCombonationsPerProduct(int product)
    {
      var result = new List<string>();
      var start = 1;
      while (start < product)
      {
        var mod = product % start;

        if (mod == 0)
        {
          var factor = product / start;
          var combonation = $"{start} x {factor}";
          // Add to list
          result.Add(combonation);
        }
        start++;
      }

      return result;
    }
  }
}
