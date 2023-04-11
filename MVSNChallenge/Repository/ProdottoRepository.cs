using Microsoft.AspNetCore.Mvc;
using MVSNChallenge.Models.DB;
using MVSNChallenge.Models;

namespace MVSNChallenge.Repository
{
    public class ProdottoRepository
    {

        public bool caricaProdotto(ProdottoCRUD prodotto)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (dbserver.Prodottis.FirstOrDefault(x => x.NomeProdotto == prodotto.NomeProdotto && x.CategoriaMerceologica == prodotto.CategoriaMerceologica) != null)
                    {
                        return false;
                    }
                    else
                    {
                        if (prodotto.IDCompagnia == null)
                            return false;
                        Prodotti insert = new Prodotti()
                        {
                            NomeProdotto = prodotto.NomeProdotto,
                            CategoriaMerceologica = prodotto.CategoriaMerceologica,
                            Quantita = prodotto.Quantita,
                            Idcompagnia = int.Parse(prodotto.IDCompagnia.ToString())
                        };
                        dbserver.Prodottis.Add(insert);
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


        public List<Prodotti>? getProdotti(MvsnchallengeContext _dbContext)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Prodottis.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<Prodotti>? getProdotto(MvsnchallengeContext _dbContext, int IDProdotto)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    return _dbContext.Prodottis.Where(x => x.Id == IDProdotto).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool updateProdotto(ProdottoCRUD prodotto)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    if (prodotto.Id == null)
                        return false;
                    var prodottoDaAggiornare = dbserver.Prodottis.FirstOrDefault(x => x.Id == prodotto.Id);
                    if (prodottoDaAggiornare != null)
                    {
                        if (prodotto.NomeProdotto != null)
                            prodottoDaAggiornare.NomeProdotto = prodotto.NomeProdotto;
                        if (prodotto.CategoriaMerceologica != null)
                            prodottoDaAggiornare.CategoriaMerceologica = prodotto.CategoriaMerceologica;
                        if (prodotto.Quantita != null)
                            prodottoDaAggiornare.Quantita = prodotto.Quantita;
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

        public bool deleteProdotto(int ID)
        {
            try
            {
                using (MvsnchallengeContext dbserver = new MvsnchallengeContext())
                {
                    var prodottoDaCancellare = dbserver.Prodottis.FirstOrDefault(x => x.Id == ID);
                    if (prodottoDaCancellare != null)
                    {
                        dbserver.Prodottis.Remove(prodottoDaCancellare);
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
