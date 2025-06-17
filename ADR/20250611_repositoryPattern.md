# ADR: Impl�mentation du Repository Pattern pour l'acc�s aux entit�s du domaine

## Statut
? Accept� � 2025-06-11

## ?? Contexte
Notre application utilise un mod�le en **architecture hexagonale / clean architecture**, dans laquelle la **couche domaine** ne doit jamais d�pendre de la **technologie de persistance** (ex: Entity Framework).

Pour respecter cette contrainte, nous devons extraire l'acc�s aux donn�es dans des abstractions c�t� domaine, et fournir des impl�mentations dans l'infrastructure.

---

## ? D�cision
Nous avons adopt� le **Repository Pattern** afin d'encapsuler les op�rations de lecture/�criture de nos entit�s m�tier dans des interfaces.

### ?? Objectifs :
- **Isoler l'acc�s aux donn�es** pour prot�ger le domaine des d�tails d'impl�mentation.
- Permettre une **facilit� de test** (mock des repositories).
- Suivre le principe de **DIP (Dependency Inversion Principle)** du SOLID.
- Rendre l�architecture **extensible et �volutive** (ex: migration vers MongoDB ou API externe).

---

## ??? D�tails de l�impl�mentation

### Interface g�n�rique
```csharp
public interface IBaseRepository<T> where T : IEntity
{
    Task<T?> GetAsync(Guid id);
}