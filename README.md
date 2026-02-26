# Gestion de Stock de Produits (ASP.NET MVC)

## 📝 Description du projet
[cite_start]Cette application est une solution complète de gestion de stock développée dans le cadre d'un exercice pratique pour un centre de formation[cite: 1, 2]. [cite_start]Elle permet de gérer un catalogue de produits et de suivre l'historique des mouvements de stock (entrées et sorties)[cite: 3].

L'architecture repose sur une séparation claire des responsabilités :
* [cite_start]**DAL (Data Access Layer)** : Communication avec la base de données via ADO.NET et procédures stockées[cite: 4, 5].
* [cite_start]**BLL (Business Logic Layer)** : Logique métier et entités[cite: 5].
* [cite_start]**ASP.NET MVC** : Interface utilisateur et modèles de vue (ViewModels)[cite: 5].

## 🚀 Fonctionnalités
* [cite_start]**Liste des produits** : Affichage de tous les produits enregistrés dans la base de données[cite: 22].
* [cite_start]**Gestion des produits** : Création, édition et suppression de produits[cite: 23].
* [cite_start]**Règle de suppression** : Un produit ne peut être supprimé que s'il n'a aucun historique de stock[cite: 23].
* [cite_start]**Détails & Stock** : Vue détaillée incluant le stock actuel et la liste complète des mouvements[cite: 24].
* [cite_start]**Mouvements de stock** : Ajout ou retrait de quantités avec vérification du stock disponible (interdiction de descendre en dessous de zéro)[cite: 25, 26, 27].

## 🛠 Technologies utilisées
* C# / .NET 6+
* ASP.NET Core MVC
* SQL Server (Procédures stockées)
* ADO.NET
* Bootstrap (pour le design)

## 📊 Base de données
L'application utilise deux tables principales liées par une clé étrangère :
* [cite_start]`Product` : Stocke les informations de base (Nom, Description, Prix)[cite: 7, 8, 10, 12, 13].
* [cite_start]`StockEntry` : Stocke chaque opération (Date, Quantité) liée à un produit[cite: 14, 15, 17, 19, 20].

## ⚙️ Installation
1. Cloner le dépôt.
2. Exécuter le script SQL fourni pour créer la base de données et les procédures stockées.
3. Modifier la chaîne de connexion dans le fichier `appsettings.json`.
4. Lancer l'application via Visual Studio.