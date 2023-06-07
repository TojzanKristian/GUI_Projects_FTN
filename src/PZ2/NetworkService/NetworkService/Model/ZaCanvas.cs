using System.Collections.Generic;

namespace NetworkService.Model
{
    public class ZaCanvas
    {
        // Pomoćni rečnik za Canvase
        public static Dictionary<string, T2_PotrosnjaStruje> CanvasObjects { get; set; } = new Dictionary<string, T2_PotrosnjaStruje>();
    }
}