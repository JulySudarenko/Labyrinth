using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Labyrinth
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                //_data = new PlayerPrefsData();
            }
            else
            {
                _data = new JsonData<SavedData>();
                //_data = new XMLData();
            }

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(PlayerBase player, ListInteractiveObject interactiveObject)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            List<SavedData> saveList = new List<SavedData>();

            var savePlayer = new SavedData
            {
                Position = player.transform.position,
                Name = player.name,
                //Speed = player.Speed,
                IsEnabled = player.enabled,
            };

            savePlayer.AddTo(saveList);
            foreach (var i in interactiveObject)
            {
                if (i is InteractiveObject bonus)
                {
            
                    var saveBonus = new SavedData
                    {
                        Position = bonus.transform.position,
                        Name = bonus.name,
                        IsEnabled = bonus.IsInteractable,
                    };
            
                    saveBonus.AddTo(saveList);
                }
            }

            _data.Save(saveList, Path.Combine(_path, _fileName));
        }

        public void Load(PlayerBase player, ListInteractiveObject interactiveObject)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new ArgumentException("File not found");
            }
            var loadGame = new List<SavedData>();
            loadGame = _data.Load(file);
 
            foreach (var str in loadGame)
            {
                if (str.Name == player.name)
                {
                    player.transform.position = str.Position;
                    //player.Speed = str.Speed;
                    player.gameObject.SetActive(str.IsEnabled);
                }

                foreach (var obj in interactiveObject)
                {
                    if (obj is InteractiveObject bonus)
                    {
                        if (str.Name == bonus.name)
                        {
                            bonus.transform.position = str.Position;
                            bonus.IsInteractable = str.IsEnabled;
                        }
                    }
                }
            }
        }
    }
}
