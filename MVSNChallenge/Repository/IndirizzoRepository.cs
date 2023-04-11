using Microsoft.AspNetCore.Mvc;
using MVSNChallenge.Models.DB;
using MVSNChallenge.Models;

namespace MVSNChallenge.Repository
{
    public class IndirizzoRepository
    {

        public bool caricaIndirizzo(IndirizzoCRUD indirizzo)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (dbserver.Indirizzis.FirstOrDefault(x => x.Indirizzo == indirizzo.Indirizzo && x.Citta == indirizzo.Citta && x.InfoAggiuntive == indirizzo.InfoAggiuntive) != null)
                    {
                        return false;
                    }
                    else
                    {
                        if (indirizzo.IDCompagnia == null)
                            return false;
                        Indirizzi insert = new Indirizzi()
                        {
                            Indirizzo = indirizzo.Indirizzo,
                            Citta = indirizzo.Citta,
                            InfoAggiuntive = indirizzo.InfoAggiuntive,
                            Idcompagnia = int.Parse(indirizzo.IDCompagnia.ToString())
                        };
                        dbserver.Indirizzis.Add(insert);
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


        public List<Indirizzi>? getIndirizziByCitta(MvsnchallengeContext _dbContext, string citta)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Indirizzis.Where(x => x.Citta == citta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Indirizzi>? getIndirizziByCompagnia(MvsnchallengeContext _dbContext, int IDCompagnia)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Indirizzis.Where(x => x.Idcompagnia == IDCompagnia).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool updateIndirizzo(IndirizzoCRUD indirizzo)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (indirizzo.Id == null)
                        return false;
                    var indirizzoDaAggiornare = dbserver.Indirizzis.FirstOrDefault(x => x.Id == indirizzo.Id);
                    if (indirizzoDaAggiornare != null)
                    {
                        if (indirizzo.Indirizzo != null)
                            indirizzoDaAggiornare.Indirizzo = indirizzo.Indirizzo;
                        if (indirizzo.Citta != null)
                            indirizzoDaAggiornare.Citta = indirizzo.Citta;
                        if (indirizzo.Indirizzo != null)
                            indirizzoDaAggiornare.InfoAggiuntive = indirizzo.InfoAggiuntive;
                        dbserver.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //Indirizzo non esistente
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteIndirizzo(int ID)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    var indirizzoDaCancellare = dbserver.Indirizzis.FirstOrDefault(x => x.Id == ID);
                    if (indirizzoDaCancellare != null)
                    {
                        dbserver.Indirizzis.Remove(indirizzoDaCancellare);
                        dbserver.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //Prodotto non esistente
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
