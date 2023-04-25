using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// Uses the TunnelingVignette XRI Sample asset to perform a fade in/out teleport.
/// </summary>
public class FadeTeleportationProvider : TeleportationProvider
{
    private static readonly int FadeID = Shader.PropertyToID("_FadeAmount");
    private static readonly int ColorID = Shader.PropertyToID("_FadeColor");

    [Header("This Teleportation Provider should replace the original Teleportation Provider.")]
    [SerializeField] [ColorUsage(false, true)]
    private Color _fadeColor = Color.black;

    [SerializeField]
    private float _fadeInTime = 0.3f;

    [SerializeField]
    private float _fadeOutTime = 0.3f;

    private TeleportRequest _currentRequest;
    private float _currentFade;
    private float _delayTimer;
    private State _currentState = State.None;
    private Renderer _renderer;

    protected override void Awake()
    {
        base.Awake();
        _renderer = GetComponent<Renderer>();
        _renderer.material.SetColor(ColorID, _fadeColor);
    }

    public override bool QueueTeleportRequest(TeleportRequest teleportRequest)
    {
        if (_currentState != State.None)
            return false;

        _currentState = State.FadeIn;
        _currentRequest = teleportRequest;
        return false;
    }

    protected override void Update()
    {
        base.Update();

        switch (_currentState)
        {
            case State.None:
                return;

            case State.FadeIn:
                _currentFade += Time.deltaTime;
                float ratio = _currentFade / _fadeInTime;
                _renderer.material.SetFloat(FadeID, ratio);

                if (_currentFade >= _fadeInTime)
                {
                    base.QueueTeleportRequest(_currentRequest);
                    _currentState = State.Delay;
                    _currentFade = 0;
                }
                break;

            case State.Delay:
                _delayTimer += Time.deltaTime;

                if (_delayTimer >= delayTime)
                {
                    _currentState = State.FadeOut;
                    _delayTimer = 0;
                }
                break;

            case State.FadeOut:

                _currentFade += Time.deltaTime;
                ratio = 1 - (_currentFade / _fadeOutTime);
                _renderer.material.SetFloat(FadeID, ratio);

                if (_currentFade >= _fadeOutTime)
                {
                    _currentState = State.None;
                    _currentFade = 0;
                }
                break;
        }
    }

    private enum State
    {
        None = 0,
        FadeIn,
        Delay,
        FadeOut,
    }
}
