using StrongHouseOwner.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StrongHouseOwner.Data.Repository
{
    public class WallingRepository
    {
        StrongHouseDBEntities objEntity;

        public TypeOfWalling ExistWallingTypeRP(TypeOfWalling objWallingType)
        {

            try
            {
                
                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfWallings.Where(x => x.WallingTypeDeletion != 1 && x.WallingTypeCategory.ToUpper() == objWallingType.WallingTypeCategory.ToUpper() && x.WallingType.ToUpper() == objWallingType.WallingType.ToUpper()).FirstOrDefault();
                
                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfWallingSample ExistSampleRP(TypeOfWallingSample objWallingSample, Boolean paintOrTile)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                TypeOfWallingSample objResult;

                if (paintOrTile == true)
                {

                    objResult = objEntity.TypeOfWallingSamples.Where(x => x.TypeOfWallingRefId == objWallingSample.TypeOfWallingRefId && x.ShopRefId == objWallingSample.ShopRefId && x.WallingTypeSampleCode.ToUpper() == objWallingSample.WallingTypeSampleCode.ToUpper() && x.WallingTypeSampleName.ToUpper() == objWallingSample.WallingTypeSampleName.ToUpper() && x.WallingTypeBrand.ToUpper() == objWallingSample.WallingTypeBrand.ToUpper() && x.WallingMilliliters == objWallingSample.WallingMilliliters).FirstOrDefault();

                }
                else
                {
                    objResult = objEntity.TypeOfWallingSamples.Where(x => x.TypeOfWallingRefId == objWallingSample.TypeOfWallingRefId && x.ShopRefId == objWallingSample.ShopRefId && x.WallingTypeSampleCode.ToUpper() == objWallingSample.WallingTypeSampleCode.ToUpper() && x.WallingTypeSampleName.ToUpper() == objWallingSample.WallingTypeSampleName.ToUpper() && x.WallingTypeSampleSizeHeight == objWallingSample.WallingTypeSampleSizeHeight && x.WallingTypeSampleSizeWidth == objWallingSample.WallingTypeSampleSizeWidth).FirstOrDefault();


                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public void SaveWallingTypeRP(TypeOfWalling objWallingType)
        {

            objEntity = new StrongHouseDBEntities(); 
            objEntity.TypeOfWallings.Add(objWallingType);
            objEntity.SaveChanges();

        }

        public TypeOfWallingSample SaveSampleRP(TypeOfWallingSample objWallingSample)
        {

            objEntity = new StrongHouseDBEntities();
            objEntity.TypeOfWallingSamples.Add(objWallingSample);
            objEntity.SaveChanges();

            return objWallingSample;

        }
        


        public List<TypeOfWalling> GetWallingListTypesRP()
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfWallings.Where(x => x.WallingTypeDeletion != 1).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public TypeOfWalling GetWallingTypeRP(int WallingTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfWallings.Where(x =>x.WallingTypeId == WallingTypeId && x.WallingTypeDeletion != 1).Include(x=>x.TypeOfWallingSamples).FirstOrDefault();

                foreach(var i in objResult.TypeOfWallingSamples)
                {

                    System.Diagnostics.Debug.WriteLine(i.WallingTypeSampleId);

                }

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }


        public List<TypeOfWallingSample> SamplesListRP(int WallingTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfWallingSamples.Where(x => x.TypeOfWallingRefId == WallingTypeId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfWallingSample SamplesRP(int WallingSampleId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfWallingSamples.Where(x => x.WallingTypeSampleId == WallingSampleId).FirstOrDefault();

                //foreach (var i in objResult)
                //{

                //    System.Diagnostics.Debug.WriteLine(i.WallingTypeSampleId);

                //}

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public List<TypeOfWallingSample> SameSamplesRP(string wallingTypeSampleName, string wallingTypeSampleCode, int wallingTypeId)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();
                var objResult = objEntity.TypeOfWallingSamples.Where(x => (x.WallingTypeSampleName == wallingTypeSampleName || x.WallingTypeSampleCode == wallingTypeSampleCode) && x.TypeOfWallingRefId == wallingTypeId).ToList();

                return objResult;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfWalling EditWallingTypeRP(TypeOfWalling objWallingType)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objWallingType).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objWallingType;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfWallingSample EditSampleRP(TypeOfWallingSample objWallingSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                objEntity.Entry(objWallingSample).State = EntityState.Modified;
                objEntity.SaveChanges();

                return objWallingSample;

            }
            catch (Exception)
            {

                return null;

            }

        }
        public TypeOfWalling DeleteWallingTypeRP(TypeOfWalling objWallingType)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                TypeOfWalling tf = objEntity.TypeOfWallings.Find(Convert.ToInt32(objWallingType.WallingTypeId));
                tf.WallingTypeDeletion = 1;

                objEntity.Entry(tf).State = EntityState.Modified;
                objEntity.SaveChanges();

                return tf;

            }
            catch (Exception)
            {

                return null;

            }

        }

        public TypeOfWallingSample DeleteSampleRP(TypeOfWallingSample objWallingSample)
        {

            try
            {

                objEntity = new StrongHouseDBEntities();

                TypeOfWallingSample fs = objEntity.TypeOfWallingSamples.Find(Convert.ToInt32(objWallingSample.WallingTypeSampleId));

                objEntity.TypeOfWallingSamples.Remove(fs);
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