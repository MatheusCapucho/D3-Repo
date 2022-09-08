public interface IInteractable
{
    float MaxRange { get; }

    void OnInteract();
    void OnHoverEnter();
    void OnHoverExit();
}
