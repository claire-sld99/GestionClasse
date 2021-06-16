/*==============================================================*/
/* Nom de SGBD :  MySQL 5.0                                     */
/* Date de creation :  16/06/2021 10:09:36                      */
/*==============================================================*/

/*==============================================================*/
/* Table : Professeur                                        */
/*==============================================================*/
create table Professeur
(
   ProfesseurID         int not null ,
   ProfesseurNom        longtext ,
   ProfesseurPrenom     longtext ,
   primary key (ProfesseurID)
);

/*==============================================================*/
/* Table : Classe                                             */
/*==============================================================*/
create table Classe
(
   ClasseID             int not null ,
   ClasseNom            char(1) ,
   ClasseNiveau         longtext ,
   primary key (ClasseID)
);

/*==============================================================*/
/* Table : Eleve                                              */
/*==============================================================*/
create table Eleve
(
   EleveID              int not null ,
   ClasseID             int ,
   EleveNom             longtext ,
   ElevePrenom          longtext ,
   EleveSexe            char(1) ,
   EleveAdresse         longtext ,
   EleveCodePostal      longtext ,
   EleveVille           longtext ,
   EleveTelephone       longtext ,
   primary key (EleveID),
   FOREIGN KEY (ClasseID) REFERENCES Classe(ClasseID)
);

/*==============================================================*/
/* Table : Evaluation                                          */
/*==============================================================*/
create table Evaluation
(
   ClasseID             int ,
   EvaluationID         int not null ,
   ProfesseurID         int ,
   EvaluationLibelle    longtext ,
   EvaluationDate       datetime ,
   EvaluationMatiere    longtext ,
   primary key (EvaluationID),
   FOREIGN KEY (ClasseID) REFERENCES Classe(ClasseID),
   FOREIGN KEY (ProfesseurID) REFERENCES Professeur(ProfesseurID)
);

/*==============================================================*/
/* Table : Note                                                */
/*==============================================================*/
create table Note
(
   EleveID              int not null ,
   EvaluationID         int ,
   NoteID               int not null ,
   NoteValeur           decimal ,
   primary key (NoteID),
   FOREIGN KEY (EleveID) REFERENCES Eleve(EleveID),
   FOREIGN KEY (EvaluationID) REFERENCES Evaluation(EvaluationID)
);

