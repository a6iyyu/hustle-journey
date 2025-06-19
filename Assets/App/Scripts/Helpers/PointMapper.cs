using Unity.VisualScripting;
namespace Assets.App.Scripts.Helpers
{
    public class PointMapper
    {
        public static float MapPointToReal(float point, float min, float max)
        {
            var real = min + point * (max - min) / 100f;
            return real;
        }
        public static float MapRealToPoint(float realValue, float min, float max)
        {
            var point = (realValue - min) / (max - min) * 100f;
            return point;
        }
    }
}