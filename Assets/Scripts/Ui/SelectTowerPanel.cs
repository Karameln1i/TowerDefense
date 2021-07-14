using System;
using System.Collections;
using System.Collections.Generic;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class SelectTowerPanel : MonoBehaviour
{
   [SerializeField] private Animator _animator;
   [SerializeField] private GameObject _towerLocationSpawn;
   [SerializeField] private GameObject _container;
   [SerializeField] private Player _player;
   [SerializeField] private AudioSource _audioSource;
   
   private TowerInstallationSite _installationSite;

   private void OnEnable()
   {
       Rotate();
   }

  private void Rotate()
   {
       _animator.Play("Rotate");
   }

   public void Open(TowerInstallationSite installationSite)
   {
       gameObject.SetActive(true);
       _installationSite = installationSite;
       _audioSource.Play();
   }
   
   public void Close()
   {
       gameObject.SetActive(false);
   }

   public void PutUpTower(Tower template)
   {
       if (_installationSite.IsEmpty&&_player.Money >= template.Price)
       {
           var tower=Instantiate(template,_container.transform);
           tower.transform.position = _towerLocationSpawn.transform.position;
           _installationSite.TowerInstaled();
           Debug.Log(_installationSite.IsEmpty);
           _player.TakeAwayMoney(template.Price);
       }
   }
   
}