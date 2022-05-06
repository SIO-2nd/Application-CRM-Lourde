# Application CRM Lourde

<h3>Sommaire :</h3>
<li><a href="#presentation">Présentation de l'application</a></li>
<li><a href="#docs">Documentation développeur</a></li>
<li><a href="#credits">Crédits</a></li>

<h2 id="presentation">Présentation de l'application</h2>

<p>L'application CRM Lourde est une application de type Windows permettant l’ajout, la modification<br>
et la Suppression des clients, des prospects, des rendez-vous et la visualisation des factures.</p>

<p>Voici son interface principale</p>

<img src="img\App.png"/>

<p>Elle a plusieurs onglets</p>

<img src="img\Menus.png"/>

<p>Une zone d'affichage des différentes données</p>

<img src="img\Datas.png"/>

<p>Une partie pour altérer ces données, en ajouter de nouvelles ou en supprimer</p>

<img src="img\Form.png"/>

<p>Ainsi qu'une partie de paramètres pour modifier ses identifiants ou ceux de la base de données utilisée</p>

<img src="img\Settings.png"/>

<h2 id="docs">Documentation développeur</h2>

<p>L'application a été développée en langage C# utilisant le mode WPF<br>
à l'aide du logiciel Visual Studio 2019 développé par Microsoft.</p>
<p>Elle possède plusieurs classes construites comme ceci.</p>

```
    public class Example
    {

        private int _Number;
        private string _Text;

        public Produits(int Number, string Text)
        {
            Number = _Number;
            Text = _Text;
        }

        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

    }
```

<p>Elle récupère les informations de la base de données utilisant cette méthode</p>

```
        public List<List> GetList()
        {
            try
            {
                requete = "select * from table";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);
                MySqlDataReader resultat = commande.ExecuteReader();

                List<List> cList = new List<List>();

                while (resultat.Read())
                {
                    List tmpList = new List(
                        Convert.ToInt32(resultat["Number"]), 
                        Convert.ToString(resultat["String"]));
                    cList.Add(tmpList);
                }

                connexion.Close();
                return cList;
            }
            catch (MySqlException error)
            {
                connexion.Close();
                Console.WriteLine("Erreur GetList : " + error.Message);
                return new List<List>();
            }

        }
```

<p>Elle ajoute des données dans la base de données utilisant cette méthode</p>

```
        public void PostList(List List)
        {
            try
            {
                requete = "INSERT INTO table(number, text) VALUES (@Number, @Text)";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Number", List.NUMBER);
                commande.Parameters.AddWithValue("@Text", List.TEXT);

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PostList : " + ex.Message);
            }
        }
```

<p>Elle modifie des données dans la base de données utilisant cette méthode</p>

```
        public void PutList(List List)
        {
            try
            {
                requete = "update table set number = @Number, text = @Text where number = @Number";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Number", Convert.ToString(List.NUMBER));
                commande.Parameters.AddWithValue("@Text", Convert.ToString(List.TEXT));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur PutList : " + ex.Message);
            }
        }
```

<p>Elle supprime des données dans la base de données utilisant cette méthode</p>

```
        public void DeleteList(int id)
        {
            try
            {
                requete = "delete from table where number = @Number";

                connexion.Open();

                MySqlCommand commande = new MySqlCommand(requete, connexion);

                commande.Parameters.AddWithValue("@Number", Convert.ToString(number));

                commande.ExecuteNonQuery();

                connexion.Close();
            }
            catch (MySqlException ex)
            {
                connexion.Close();
                Console.WriteLine("Erreur DeleteList " + ex.Message);
            }
        }
```

<h2 id="credits">Crédits</h2>

<p>L'application CRM Lourde a été développée par <a href="https://github.com/Str4ky">REQUISTON Timothé</a>,<br>
<a href="https://github.com/Goupil117">PEYRONNET Philippe</a> et <a href="https://github.com/mateocarciu">CARCIU Mateo</a> dans le cadre du BTS.</p>
