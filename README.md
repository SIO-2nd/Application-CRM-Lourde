# Application CRM Lourde

<h3>Sommaire :</h3>
<li><a href="#presentation">Présentation de l'application</a></li>
<li><a href="#docs">Documentation développeur</a></li>
<li><a href="#copirights">Copyrights</a></li>

<h2 id="presentation">Présentation de l'application</h2>

<p>L'application CRM Lourde est une application de type Windows permettant l’ajout, la modification et la
Suppression des clients, des prospects, des rendez-vous et la visualisation des factures.</p>

<p>Voici son interface principale</p>

<img src="img\Interface.png"/>

<p>Elle a plusieurs onglets</p>

<img src="img\Tabs.png"/>

<p>Une zone d'affichage des différentes données</p>

<img src="img\Datagrid.png"/>

<p>Ainsi qu'une partie pour altérer ces données ou en ajouter de nouvelles</p>

<img src="img\Form.png"/>

<h2 id="docs">Documentation développeur</h2>

<p>L'application a été développée en langage C# utilisant le mode WPF à l'aide du logiciel Visual Studio 2019 développé par Microsoft.</p>
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
        public static List<Liste> GetListe()
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from table";

                SqlDataReader dataReader = command.ExecuteReader();
                List<Liste> cListe = new List<Liste>();
                while (dataReader.Read())
                {
                    Liste tmpListe = new Liste(
                        Convert.ToInt32(dataReader["Number"]),
                        Convert.ToString(dataReader["Text"])
                    );
                    cListe.Add(tmpListe);
                }
                dataReader.Close();
                return cListe;
            }
            catch
            {
                Console.WriteLine("Erreur GetListe");
                return new List<Liste>();
            }
        }
```

<p>Elle ajoute des données dans la base de données utilisant cette méthode</p>

```
        public static void PutListe(Liste lst)
        {
            try
            {
                String requete = "INSERT INTO table(Number, Text) VALUES (@Text, @Number)";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Number", Convert.ToString(lst.Number));
                command.Parameters.AddWithValue("@Text", Convert.ToString(lst.Text));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur PutListe");
            }
        }
```

<p>Elle modifie des données dans la base de données utilisant cette méthode</p>

```
        public static void EditListe(Liste lst)
        {
            try
            {
                String requete = "update table set Number = @Number, Text = @Text";

                SqlCommand command = new SqlCommand(requete, connection);

                command.Parameters.AddWithValue("@Number", Convert.ToString(com.Number));
                command.Parameters.AddWithValue("@Text", Convert.ToString(com.Text));

                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur EditListe");
            }
        }
```

<p>Elle supprime des données dans la base de données utilisant cette méthode</p>

```
        public static void DeleteListe(string Number)
        {
            try
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "delete from commercial where Number = " + Number;
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur DeleteListe");
            }
        }
```

<h2 id="copirights">Copyrights</h2>

<p>L'application CRM Lourde a été développée par REQUISTON Timothé, PEYRONNET Philippe et CARCIU Mateo dans le cadre du BTS.</p>
