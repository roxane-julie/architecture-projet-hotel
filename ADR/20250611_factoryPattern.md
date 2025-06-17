Utilisation du Factory Pattern pour la g�n�ration des donn�es de chambre selon le r�le utilisateur
Statut

Accept� � 2025-06-11
Contexte

Dans notre application de gestion h�teli�re, il est n�cessaire d'exposer une liste de chambres disponibles � un utilisateur pour une plage de dates donn�e.
Les informations retourn�es doivent varier selon le r�le de l'utilisateur :

    Un Client voit uniquement les informations publiques : nom, disponibilit�, prix, etc.

    Un Administrateur ou R�ceptionniste acc�de � des donn�es plus compl�tes : statut de maintenance, historique de r�servation, etc.

Initialement, cette logique aurait pu �tre g�r�e via des if/switch dans le code de service, ce qui violerait le principe O du SOLID (Open/Closed Principle) et rendrait le code difficile � maintenir.
D�cision

Nous avons d�cid� d�appliquer le Factory Pattern pour d�l�guer la cr�ation de la structure de r�ponse (RoomData) � des classes sp�cifiques � chaque r�le.
Impl�mentation

    Une interface IRoomDataFactory d�finit un contrat unique : RoomData Create(List<Room> rooms)

    Chaque r�le a une impl�mentation d�di�e :

        CustomerRoomDataFactory

        AdminRoomDataFactory

    Un RoomDataFactoryResolver permet de r�cup�rer dynamiquement la factory appropri�e � partir du r�le utilisateur (injection via DI).

Ce pattern permet de :

    Respecter le principe de responsabilit� unique (SRP) en d�l�guant la logique sp�cifique � chaque r�le.

    Appliquer le Open/Closed Principle (OCP) : pour ajouter un r�le, il suffit d�ajouter une nouvelle classe, sans modifier l�existant.

    Faciliter les tests unitaires, chaque factory pouvant �tre test�e isol�ment.

    Supprimer tout switch ou if bas� sur le r�le dans le c�ur de la logique m�tier.

Cons�quences

    Le code est plus modulaire et maintenable, mais il y a une l�g�re complexit� initiale (injection multiple de strat�gies).

    Il est facile d��tendre la logique (ex: ajout d�un r�le Nettoyeur) sans impacter les factories existantes.

    Le pattern peut �tre r�utilis� dans d�autres parties du projet o� une logique m�tier varie selon un contexte (ex: notifications, droits d�acc�s�).

Alternatives envisag�es

    Utiliser un switch/if dans le service pour cr�er manuellement les bons types de donn�es. Rejet� pour cause de manque de modularit�, difficult� de tests, et non respect des principes SOLID.