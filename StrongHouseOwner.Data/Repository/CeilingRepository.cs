using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class CeilingRepository
    {
        StrongHouseDBEntities objEntity;

        public TypeOfCeiling ExistCeilingTypeRP(TypeOfCeiling objCeilingType)
        {

            try
            {
                
                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilings.Where(x => x.CeilingTypeDeletion != 1 && x.CeilingTypeCategory.ToUpper() == objCeilingType.CeilingTypeCategory.ToUpper() && x.CeilingType.ToUpper() == objCeilingType.CeilingType.ToUpper()).FirstOrDefault();
                
                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfCeilingSample ExistSampleRP(TypeOfCeilingSample objCeilingSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilingSamples.Where(x => x.TypeOfCeilingRefId == objCeilingSample.TypeOfCeilingRefId && x.ShopRefId == objCeilingSample.ShopRefId && x.CeilingTypeSampleCode.ToUpper() == objCeilingSample.CeilingTypeSampleCode.ToUpper() && x.CeilingTypeSampleName.ToUpper() == objCeilingSample.CeilingTypeSampleName.ToUpper() && x.CeilingTypeSampleSizeHeight == objCeilingSample.CeilingTypeSampleSizeHeight && x.CeilingTypeSampleSizeWidth == objCeilingSample.CeilingTypeSampleSizeWidth).FirstOrDefault();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public void SaveCeilingTypeRP(TypeOfCeiling objCeilingType)
        {

            objEntity = new StrongHouseDBEntities(); 
            objEntity.TypeOfCeilings.Add(objCeilingType);
            objEntity.SaveChanges();

        }

        public TypeOfCeilingSample SaveSampleRP(TypeOfCeilingSample objCeilingSample)
        {
            System.Diagnostics.Debug.WriteLine(objCeilingSample.TypeOfCeilingRefId); 

            objEntity = new StrongHouseDBEntities();
            objEntity.TypeOfCeilingSamples.Add(objCeilingSample);
            objEntity.SaveChanges();

            return objCeilingSample;

        }
        


        public List<TypeOfCeiling> GetCeilingListTypesRP()
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilings.Where(x => x.CeilingTypeDeletion != 1).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public TypeOfCeiling GetCeilingTypeRP(int CeilingTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilings.Where(x =>x.CeilingTypeId == CeilingTypeId && x.CeilingTypeDeletion != 1).Include(x=>x.TypeOfCeilingSamples).FirstOrDefault();

                foreach(var i in objResult.TypeOfCeilingSamples)
                {

                    System.Diagnostics.Debug.WriteLine(i.CeilingTypeSampleId);

                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public List<TypeOfCeilingSample> SamplesListRP(int CeilingTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilingSamples.Where(x => x.TypeOfCeilingRefId == CeilingTypeId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfCeilingSample SamplesRP(int CeilingSampleId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilingSamples.Where(x => x.CeilingTypeSampleId == CeilingSampleId).FirstOrDefault();

                //foreach (var i in objResult)
                //{

                //    System.Diagnostics.Debug.WriteLine(i.CeilingTypeSampleId);

                //}

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<TypeOfCeilingSample> SameSamplesRP(string ceilingTypeSampleName, string ceilingTypeSampleCode, int ceilingTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfCeilingSamples.Where(x => (x.CeilingTypeSampleName == ceilingTypeSampleName || x.CeilingTypeSampleCode == ceilingTypeSampleCode) && x.TypeOfCeilingRefId == ceilingTypeId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }
        public TypeOfCeiling EditCeilingTypeRP(TypeOfCeiling objCeilingType)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objCeilingType).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objCeilingType;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfCeilingSample EditSampleRP(TypeOfCeilingSample objCeilingSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objCeilingSample).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objCeilingSample;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfCeiling DeleteCeilingTypeRP(TypeOfCeiling objCeilingType)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                TypeOfCeiling tf = objEntity.TypeOfCeilings.Find(Convert.ToInt32(objCeilingType.CeilingTypeId));
                tf.CeilingTypeDeletion = 1;

                objEntity.Entry(tf).State = EntityState.Modified;
                objEntity.SaveChanges();

                return tf;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfCeilingSample DeleteSampleRP(TypeOfCeilingSample objCeilingSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                TypeOfCeilingSample fs = objEntity.TypeOfCeilingSamples.Find(Convert.ToInt32(objCeilingSample.CeilingTypeSampleId));

                objEntity.TypeOfCeilingSamples.Remove(fs);
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