using System;
using System.Collections.Generic;

namespace DataObjects
{
    /// <summary>
    /// Manager classes are an abstraction on the data access layers
    /// </summary>
    public static class TeeManager
    {

        static TeeManager()
        {
        }

        public static Tee GetTee(int id)
        {
            return CompleteGolfAppRepositoryADO.GetTee(id);
        }

        public static IList<Tee> GetTees()
        {
            return new List<Tee>(CompleteGolfAppRepositoryADO.GetTees());
        }

        public static int SaveTee(Tee item)
        {
            return CompleteGolfAppRepositoryADO.SaveTee(item);
        }

        public static int DeleteTee(int id)
        {
            return CompleteGolfAppRepositoryADO.DeleteTee(id);
        }
    }
}