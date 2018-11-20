using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "SelectStage")]
[System.Serializable]
public class SelectStage : ScriptableObject
{
    [SerializeField] public bool Fase01;
    [SerializeField] public bool Fase02;
    [SerializeField] public bool Fase03;
    [SerializeField] public bool Fase04;

    public bool FaseHabilitada(int FaseAtual)
    {
        var retorno = false;
        switch (FaseAtual)
        {
            case 1:
                retorno = true;
            break;
            case 2:
                retorno = Fase02;
            break;
            case 3:
                retorno = Fase03;
            break;
            case 4:
                retorno = Fase04;
            break;
            default:            
                retorno = false;
            break;        
        }
        return retorno;
    }

    public void FaseSalva(int FaseAtual)
    {
        switch (FaseAtual)
        {
            case 1:
                Fase01 = true;
            break;
            case 2:
                Fase02 = true;
            break;
            case 3:
                Fase03 = true;
            break;
            case 4:
                Fase04 = true;
            break;
            default:            
                Fase01 = true;
            break;        
        }
    }
}