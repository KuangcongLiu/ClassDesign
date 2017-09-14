namespace IRepository
{
   
    using System.Collections.Generic;

    using POCO;

    public interface ICapeRepository
    {
        List<Cape> GetCapeList(ref List<string> errors);
        Cape GetCape(int CapeId, ref List<string> errors);

        void InsertCape(Cape cape, ref List<string> errors);

        void DeleteCape(Cape cape, ref List<string> errors);

        void UpdateCape(Cape cape, ref List<string> errors);
    }
}
