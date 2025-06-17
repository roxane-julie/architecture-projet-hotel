# ADR: Implémentation du Repository Pattern pour l'accès aux entités du domaine

## Statut
? Accepté — 2025-06-11

## ?? Contexte
Notre application utilise un modèle en **architecture hexagonale / clean architecture**, dans laquelle la **couche domaine** ne doit jamais dépendre de la **technologie de persistance** (ex: Entity Framework).

Pour respecter cette contrainte, nous devons extraire l'accès aux données dans des abstractions côté domaine, et fournir des implémentations dans l'infrastructure.

---

## ? Décision
Nous avons adopté le **Repository Pattern** afin d'encapsuler les opérations de lecture/écriture de nos entités métier dans des interfaces.

### ?? Objectifs :
- **Isoler l'accès aux données** pour protéger le domaine des détails d'implémentation.
- Permettre une **facilité de test** (mock des repositories).
- Suivre le principe de **DIP (Dependency Inversion Principle)** du SOLID.
- Rendre l’architecture **extensible et évolutive** (ex: migration vers MongoDB ou API externe).

---

## ??? Détails de l’implémentation

### Interface générique
```csharp
public interface IBaseRepository<T> where T : IEntity
{
    Task<T?> GetAsync(Guid id);
}