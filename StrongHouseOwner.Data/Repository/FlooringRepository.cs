using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class FlooringRepository
    {
        StrongHouseDBEntities objEntity;

        public TypeOfFlooring ExistFlooringTypeRP(TypeOfFlooring objFlooringType)
        {

            try
            {
                
                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFloorings.Where(x => x.FlooringTypeDeletion != 1 && x.FlooringTypeCategory.ToUpper() == objFlooringType.FlooringTypeCategory.ToUpper() && x.FlooringType.ToUpper() == objFlooringType.FlooringType.ToUpper()).FirstOrDefault();
                
                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfFlooringSample ExistSampleRP(TypeOfFlooringSample objFlooringSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFlooringSamples.Where(x => x.TypeOfFlooringRefId == objFlooringSample.TypeOfFlooringRefId && x.ShopRefId == objFlooringSample.ShopRefId && x.FlooringTypeSampleCode.ToUpper() == objFlooringSample.FlooringTypeSampleCode.ToUpper() && x.FlooringTypeSampleName.ToUpper() == objFlooringSample.FlooringTypeSampleName.ToUpper() && x.FlooringTypeSampleSizeHeight == objFlooringSample.FlooringTypeSampleSizeHeight && x.FlooringTypeSampleSizeWidth == objFlooringSample.FlooringTypeSampleSizeWidth).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public void SaveFlooringTypeRP(TypeOfFlooring objFlooringType)
        {

            objEntity = new StrongHouseDBEntities(); 
            objEntity.TypeOfFloorings.Add(objFlooringType);
            objEntity.SaveChanges();

        }

        public TypeOfFlooringSample SaveSampleRP(TypeOfFlooringSample objFlooringSample)
        {
            System.Diagnostics.Debug.WriteLine(objFlooringSample.TypeOfFlooringRefId); 

            objEntity = new StrongHouseDBEntities();
            objEntity.TypeOfFlooringSamples.Add(objFlooringSample);
            objEntity.SaveChanges();

            return objFlooringSample;

        }
        


        public List<TypeOfFlooring> GetFlooringListTypesRP()
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFloorings.Where(x => x.FlooringTypeDeletion != 1).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public TypeOfFlooring GetFlooringTypeRP(int flooringTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFloorings.Where(x =>x.FlooringTypeId == flooringTypeId && x.FlooringTypeDeletion != 1).Include(x=>x.TypeOfFlooringSamples).FirstOrDefault();

                foreach(var i in objResult.TypeOfFlooringSamples)
                {

                    System.Diagnostics.Debug.WriteLine(i.FlooringTypeSampleId);

                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public List<TypeOfFlooringSample> SamplesListRP(int flooringTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFlooringSamples.Where(x => x.TypeOfFlooringRefId == flooringTypeId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfFlooringSample SamplesRP(int flooringSampleId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFlooringSamples.Where(x => x.FlooringTypeSampleId == flooringSampleId).FirstOrDefault();

                //foreach (var i in objResult)
                //{

                //    System.Diagnostics.Debug.WriteLine(i.FlooringTypeSampleId);

                //}

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public TypeOfFlooringSample SamplesUsingNameRP(string flooringTypeSampleName, string flooringTypeSampleCode, int flooringTypeSampleSizeHeight, int flooringTypeSampleSizewidth)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFlooringSamples.Where(x => x.FlooringTypeSampleName == flooringTypeSampleName && x.FlooringTypeSampleSizeHeight == flooringTypeSampleSizeHeight && x.FlooringTypeSampleSizeWidth == flooringTypeSampleSizewidth).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

            public List<TypeOfFlooringSample> SameSamplesRP(string flooringTypeSampleName, string flooringTypeSampleCode, int flooringTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfFlooringSamples.Where(x => (x.FlooringTypeSampleName == flooringTypeSampleName || x.FlooringTypeSampleCode == flooringTypeSampleCode) && x.TypeOfFlooringRefId == flooringTypeId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public TypeOfFlooring EditFlooringTypeRP(TypeOfFlooring objFlooringType)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objFlooringType).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objFlooringType;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfFlooringSample EditSampleRP(TypeOfFlooringSample objFlooringSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objFlooringSample).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objFlooringSample;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfFlooring DeleteFlooringTypeRP(TypeOfFlooring objFlooringType)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                TypeOfFlooring tf = objEntity.TypeOfFloorings.Find(Convert.ToInt32(objFlooringType.FlooringTypeId));
                tf.FlooringTypeDeletion = 1;

                objEntity.Entry(tf).State = EntityState.Modified;
                objEntity.SaveChanges();

                return tf;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfFlooringSample DeleteSampleRP(TypeOfFlooringSample objFlooringSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                TypeOfFlooringSample fs = objEntity.TypeOfFlooringSamples.Find(Convert.ToInt32(objFlooringSample.FlooringTypeSampleId));

                objEntity.TypeOfFlooringSamples.Remove(fs);
                objEntity.SaveChanges();

                return fs;

            }
            catch (Exception)
            {

                return null;

            }

        }

    }
}