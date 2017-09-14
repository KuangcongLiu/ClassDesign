namespace Service
{
    using System.Collections.Generic;
    using IRepository;
    using POCO;
    using System;

    public class CapeService{
        private readonly ICapeRepository repository;

        public CapeService(ICapeRepository repository) {
            this.repository = repository;
        }

        public List<Cape> GetCapeList(ref List<string> errors) {
            return this.repository.GetCapeList(ref errors);
        }

        public Cape GetCape(int CapeId, ref List<string> errors)
        {
            return this.repository.GetCape(CapeId, ref errors);
        }

        public void InsertCape(Cape cape, ref List<string> errors) {
            if (cape == null){
                errors.Add("cape cannnot be null when insert");
                return;
            }

            if (cape.CapeId <= 0){
                errors.Add("cape id cannot less than 1 when insert");
                return;
            }

            if (cape.ScheduleId <= 0){
                errors.Add("schedule id cannot less than 1 when insert");
                return;
            }

            if (cape.Rate < 0 || cape.Rate > 10){
                errors.Add("rate cannot be less than 1 or greater than 10 when insert");
                return;
            }

            this.repository.InsertCape(cape, ref errors);
        }

        public void UpdateCape(Cape cape, ref List<string> errors) {
            if (cape == null)
            {
                errors.Add("cape cannnot be null when update");
                return;
            }

            /*if (cape.CapeId <= 0)
            {
                errors.Add("cape id cannot less than 1 when update");
                throw new ArgumentException();
            }*/

            if (cape.ScheduleId <= 0)
            {
                errors.Add("schedule id cannot less than 1 when update");
                return;
            }

            /*if (cape.Rate < 0 || cape.Rate > 10)
            {
                errors.Add("rate cannot be less than 1 or greater than 10 when update");
                throw new ArgumentException();
            }*/

            this.repository.UpdateCape(cape, ref errors);
        }

        public void DeleteCape(Cape cape, ref List<string> errors) {
            if (cape ==null)
            {
                errors.Add("cape id cannot less than 1 when delete");
                throw new ArgumentException();
            }
            this.repository.DeleteCape(cape, ref errors);
        }


    }
}
