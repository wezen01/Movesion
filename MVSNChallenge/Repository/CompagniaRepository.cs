using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVSNChallenge.Models;
using MVSNChallenge.Models.DB;

namespace MVSNChallenge.Repository
{
    public class CompagniaRepository
    {
        public bool caricaCompagnia(CompagniaCRUD compagnia)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (dbserver.Compagnies.FirstOrDefault(x => x.NomeCompagnia == compagnia.NomeCompagnia && x.DescrizioneCompagnia == compagnia.DescrizioneCompagnia) != null)
                    {
                        return false;
                    }
                    else
                    {
                        Compagnie insert = new Compagnie()
                        {
                            NomeCompagnia = compagnia.NomeCompagnia,
                            DescrizioneCompagnia = compagnia.DescrizioneCompagnia
                        };
                        dbserver.Compagnies.Add(insert);
                        dbserver.SaveChanges();
                        return true;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Compagnie>? getCompagnie(MvsnchallengeContext _dbContext)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Compagnies.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Compagnie>? getCompagnia(MvsnchallengeContext _dbContext, int IDCompagnia)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Compagnies.Where(x => x.Id == IDCompagnia).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool updateCompagnia(CompagniaCRUD compagnia)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (compagnia.Id == null)
                        return false;
                    var compagniaDaAggiornare = dbserver.Compagnies.FirstOrDefault(x => x.Id == compagnia.Id);
                    if (compagniaDaAggiornare != null)
                    {
                        if (compagnia.NomeCompagnia != null)
                            compagniaDaAggiornare.NomeCompagnia = compagnia.NomeCompagnia;
                        if (compagnia.DescrizioneCompagnia != null)
                            compagniaDaAggiornare.DescrizioneCompagnia = compagnia.DescrizioneCompagnia;
                        dbserver.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //Compagnia non esistente
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteCompagnia(int ID)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    var compagniaDaCancellare = dbserver.Compagnies.FirstOrDefault(x => x.Id == ID);
                    if (compagniaDaCancellare != null)
                    {
                        dbserver.Compagnies.Remove(compagniaDaCancellare);
                        dbserver.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //Compagnia non esistente
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
