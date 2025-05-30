﻿using Content.Server._NewParadise.TTS;
using Content.Shared._NewParadise.TTS;
using Content.Shared.Inventory;
using Content.Shared.VoiceMask;

namespace Content.Server.VoiceMask;

public partial class VoiceMaskSystem
{
    [Dependency] private readonly InventorySystem _inventorySystem = default!;

    private void InitializeTTS()
    {
        SubscribeLocalEvent<SharedTTSComponent, TransformSpeakerVoiceEvent>(OnSpeakerVoiceTransform);
        SubscribeLocalEvent<VoiceMaskComponent, VoiceMaskChangeVoiceMessage>(OnChangeVoice);
    }

    private void OnSpeakerVoiceTransform(EntityUid uid, SharedTTSComponent tts, TransformSpeakerVoiceEvent evt)
    {
        if (_inventorySystem.TryGetSlotEntity(uid, "mask", out var mask))
        {
            if (TryComp<VoiceMaskComponent>(mask, out var voiceMaskComponent))
            {
                evt.VoiceId = voiceMaskComponent.VoiceId;
            }
        }
    }

    private void OnChangeVoice(Entity<VoiceMaskComponent> entity, ref VoiceMaskChangeVoiceMessage message)
    {
        if (message.Voice is { } id && !_proto.HasIndex<TTSVoicePrototype>(id))
            return;

        entity.Comp.VoiceId =  message.Voice;

        _popupSystem.PopupCursor(Loc.GetString("voice-mask-voice-popup-success"), message.Actor);

        UpdateUI(entity);
    }
}
