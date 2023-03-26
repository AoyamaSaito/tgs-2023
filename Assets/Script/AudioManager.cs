using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

/// <summary>
/// �����̊Ǘ���
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// �C���X�^���X
    /// </summary>
    static AudioManager s_instance = null;

    /// <summary>
    /// �C���X�^���X
    /// </summary>
    public static AudioManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                // Resources����C���X�^���X�����Ď擾����
                AudioManager prefab = Resources.Load<AudioManager>("Audio/AudioManager");
                s_instance = Instantiate(prefab);
                DontDestroyOnLoad(s_instance);
            }

            return s_instance;
        }
    }

    /// <summary>
    /// BGM
    /// </summary>
    [SerializeField]
    CriAtomSource _bgmSource = null;

    /// <summary>
    /// SE
    /// </summary>
    [SerializeField]
    CriAtomSource _seSource = null;

    /// <summary>
    /// ���[�v����SE
    /// </summary>
    [SerializeField]
    CriAtomSource _loopSESource = null;

    /// <summary>
    /// �Đ�����BGM�̖��O
    /// </summary>
    public string PlayingBgmName { get; private set; } = string.Empty;

    /// <summary>
    /// BGM���Đ�����
    /// </summary>
    /// <param name="cueName">�L���[</param>
    /// <param name="volume">����</param>
    /// <param name="continueSameBgm">���ɓ���BGM���Đ����Ă���ꍇ�ABGM���p������</param>
    public void PlayBgm(string cueName, float volume = 1.0f, bool continueSameBgm = true)
    {
        // ���ʂ�ݒ肷��
        _bgmSource.volume = volume;

        // ����BGM���p������ꍇ�͏������I������
        if (continueSameBgm
            && _bgmSource.cueName == cueName)
        {
            return;
        }

        // ���ɍĐ����Ȃ�BGM���~����
        if (_bgmSource.status == CriAtomSourceBase.Status.Playing)
        {
            StopBgm();
        }

        // BGM���Đ�����
        _bgmSource.Play(cueName);

        // ���O���L������
        PlayingBgmName = _bgmSource.cueName;
    }

    /// <summary>
    /// BGM���~����
    /// </summary>
    public void StopBgm()
    {
        // BGM���~����
        _bgmSource.Stop();

        // ���O��Y���
        PlayingBgmName = string.Empty;
    }

    /// <summary>
    /// SE���Đ�����
    /// </summary>
    /// <param name="cueName">�L���[</param>
    /// <param name="volume">����</param>
    public void PlaySE(string cueName, float volume = 1.0f)
    {
        _seSource.volume = volume;
        _seSource.Play(cueName);
    }

    /// <summary>
    /// SE���~����
    /// </summary>
    public void StopSE()
    {
        _seSource.Stop();
    }

    /// <summary>
    /// ���[�vSE���~����
    /// </summary>
    /// <param name="cueName">�L���[��</param>
    /// <param name="volume">����</param>
    public void PlayLoopSE(string cueName, float volume = 1.0f)
    {
        _loopSESource.volume = volume;
        _loopSESource.Play(cueName);
    }

    /// <summary>
    /// ���[�vSE���~����
    /// </summary>
    public void StopLoopSE()
    {
        _loopSESource.Stop();
    }
}