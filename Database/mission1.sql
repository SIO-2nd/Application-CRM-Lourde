-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Mer 15 Septembre 2021 à 11:17
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `mission1`
--

-- --------------------------------------------------------

--
-- Structure de la table `achats`
--

CREATE TABLE `achats` (
  `IdAchat` int(11) NOT NULL,
  `IdCli` int(11) NOT NULL,
  `IdProd` int(11) NOT NULL,
  `IdQte` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

CREATE TABLE `clients` (
  `IdCli` int(11) NOT NULL,
  `NomCli` varchar(30) NOT NULL,
  `PreCli` varchar(30) NOT NULL,
  `AdrCli` varchar(100) NOT NULL,
  `CpCli` int(5) NOT NULL,
  `VilleCli` varchar(50) NOT NULL,
  `MailCli` varchar(50) NOT NULL,
  `TelCli` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `factures`
--

CREATE TABLE `factures` (
  `IdFact` int(11) NOT NULL,
  `IdCli` int(11) NOT NULL,
  `NomProd` varchar(50) NOT NULL,
  `LibProd` varchar(50) NOT NULL,
  `PrixProd` int(11) NOT NULL,
  `DateFact` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `produit`
--

CREATE TABLE `produit` (
  `IdProd` int(11) NOT NULL,
  `TypeProd` varchar(100) NOT NULL,
  `PrixProd` double NOT NULL,
  `NomProd` varchar(50) NOT NULL,
  `LibProd` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `prospects`
--

CREATE TABLE `prospects` (
  `IdPro` int(11) NOT NULL,
  `NomPro` varchar(30) NOT NULL,
  `PrePro` varchar(30) NOT NULL,
  `AdrPro` varchar(100) NOT NULL,
  `CpPro` int(5) NOT NULL,
  `VillePro` varchar(50) NOT NULL,
  `MailPro` varchar(50) NOT NULL,
  `TelPro` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `rendez-vous`
--

CREATE TABLE `rendez-vous` (
  `IdRdv` int(11) NOT NULL,
  `NomRdv` varchar(50) NOT NULL,
  `PreRdv` varchar(50) NOT NULL,
  `TelRdv` int(10) NOT NULL,
  `DateRdv` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `achats`
--
ALTER TABLE `achats`
  ADD PRIMARY KEY (`IdAchat`);

--
-- Index pour la table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`IdCli`);

--
-- Index pour la table `factures`
--
ALTER TABLE `factures`
  ADD PRIMARY KEY (`IdFact`);

--
-- Index pour la table `produit`
--
ALTER TABLE `produit`
  ADD PRIMARY KEY (`IdProd`);

--
-- Index pour la table `prospects`
--
ALTER TABLE `prospects`
  ADD PRIMARY KEY (`IdPro`);

--
-- Index pour la table `rendez-vous`
--
ALTER TABLE `rendez-vous`
  ADD PRIMARY KEY (`IdRdv`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `achats`
--
ALTER TABLE `achats`
  MODIFY `IdAchat` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `clients`
--
ALTER TABLE `clients`
  MODIFY `IdCli` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `factures`
--
ALTER TABLE `factures`
  MODIFY `IdFact` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `produit`
--
ALTER TABLE `produit`
  MODIFY `IdProd` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `prospects`
--
ALTER TABLE `prospects`
  MODIFY `IdPro` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `rendez-vous`
--
ALTER TABLE `rendez-vous`
  MODIFY `IdRdv` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
