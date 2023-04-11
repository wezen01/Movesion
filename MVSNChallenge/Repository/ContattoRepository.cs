using Microsoft.AspNetCore.Mvc;
using MVSNChallenge.Models.DB;
using MVSNChallenge.Models;

namespace MVSNChallenge.Repository
{
    public class ContattoRepository
    {
        public bool caricaContatto(ContattoCRUD contatto)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (dbserver.Contattis.FirstOrDefault(x => x.Tipo == contatto.Tipo && x.Contatto == contatto.Contatto && x.Idcompagnia == contatto.IDCompagnia) != null)
                    {
                        return false;
                    }
                    else
                    {
                        if (contatto.IDCompagnia == null)
                            return false;
                        Contatti insert = new Contatti()
                        {
                            Tipo = contatto.Tipo,
                            Contatto = contatto.Contatto,
                            Idcompagnia = int.Parse(contatto.IDCompagnia.ToString())
                        };
                        dbserver.Contattis.Add(insert);
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



        public List<Contatti>? getContattiByCompagnia(MvsnchallengeContext _dbContext, int IDCompagnia)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Contattis.Where(x => x.Idcompagnia == IDCompagnia).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Contatti>? getContatti(MvsnchallengeContext _dbContext)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Contattis.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool updateContatto(ContattoCRUD contatto)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (contatto.ID == null)
                        return false;
                    var contattoDaAggiornare = dbserver.Contattis.FirstOrDefault(x => x.Id == contatto.ID);
                    if (contattoDaAggiornare != null)
                    {
                        if (contatto.Tipo != null)
                            contattoDaAggiornare.Tipo = contatto.Tipo;
                        if (contatto.Contatto != null)
                            contattoDaAggiornare.Contatto = contatto.Contatto;
                        dbserver.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //Contatto non esistente
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool deleteContatto(int ID)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    var contattoDaCancellare = dbserver.Contattis.FirstOrDefault(x => x.Id == ID);
                    if (contattoDaCancellare != null)
                    {
                        dbserver.Contattis.Remove(contattoDaCancellare);
                        dbserver.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //Contatto non esistente
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
