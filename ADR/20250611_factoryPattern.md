Utilisation du Factory Pattern pour la génération des données de chambre selon le rôle utilisateur
Statut

Accepté – 2025-06-11
Contexte

Dans notre application de gestion hôtelière, il est nécessaire d'exposer une liste de chambres disponibles à un utilisateur pour une plage de dates donnée.
Les informations retournées doivent varier selon le rôle de l'utilisateur :

    Un Client voit uniquement les informations publiques : nom, disponibilité, prix, etc.

    Un Administrateur ou Réceptionniste accède à des données plus complètes : statut de maintenance, historique de réservation, etc.

Initialement, cette logique aurait pu être gérée via des if/switch dans le code de service, ce qui violerait le principe O du SOLID (Open/Closed Principle) et rendrait le code difficile à maintenir.
Décision

Nous avons décidé d’appliquer le Factory Pattern pour déléguer la création de la structure de réponse (RoomData) à des classes spécifiques à chaque rôle.
Implémentation

    Une interface IRoomDataFactory définit un contrat unique : RoomData Create(List<Room> rooms)

    Chaque rôle a une implémentation dédiée :

        CustomerRoomDataFactory

        AdminRoomDataFactory

    Un RoomDataFactoryResolver permet de récupérer dynamiquement la factory appropriée à partir du rôle utilisateur (injection via DI).

Ce pattern permet de :

    Respecter le principe de responsabilité unique (SRP) en déléguant la logique spécifique à chaque rôle.

    Appliquer le Open/Closed Principle (OCP) : pour ajouter un rôle, il suffit d’ajouter une nouvelle classe, sans modifier l’existant.

    Faciliter les tests unitaires, chaque factory pouvant être testée isolément.

    Supprimer tout switch ou if basé sur le rôle dans le cœur de la logique métier.

Conséquences

    Le code est plus modulaire et maintenable, mais il y a une légère complexité initiale (injection multiple de stratégies).

    Il est facile d’étendre la logique (ex: ajout d’un rôle Nettoyeur) sans impacter les factories existantes.

    Le pattern peut être réutilisé dans d’autres parties du projet où une logique métier varie selon un contexte (ex: notifications, droits d’accès…).

Alternatives envisagées

    Utiliser un switch/if dans le service pour créer manuellement les bons types de données. Rejeté pour cause de manque de modularité, difficulté de tests, et non respect des principes SOLID.