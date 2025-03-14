﻿using System;
using System.Collections.Generic;
using UnityEngine;
using GameTime.Action;
using System.Threading.Tasks;
using Objects._2D.Places;

namespace AI.Scholars
{
    public class ScholarLocation
    {
        public event Action OnLocationChanged;
        public Place MyDesk => _scholar.ClassRoom.GetMyDesk(_scholar);
        public Place MyDockStation => _scholar.ClassRoom.GetMyDockStation(_scholar);
        public Place CurrentPlace => _currentPlace;

        private Scholar _scholar;
        private Place _currentPlace;


        public ScholarLocation(Scholar scholar)
        {
            _scholar = scholar;
            Teleport(_scholar.ClassRoom.GetMyDockStation(_scholar));
        }

        public void GoTo(Place place)
        {
            if (place.Busy)
                throw new Exception("Место уже занято");

            _currentPlace?.SetBusy(false);

            _scholar.Move.SetDestination(place.Destination);

            _currentPlace = place;
            place.SetBusy(true);

            OnLocationChanged?.Invoke();
        }

        public void Teleport(Place place)
        {
            if (place.Busy)
                throw new ArgumentException();

            _currentPlace?.SetBusy(false);

            _scholar.Move.SetPosition(place.Destination);
            _scholar.Sight.LookAt(place.SightGoal);

            _currentPlace = place;
            place.SetBusy(true);

            OnLocationChanged?.Invoke();
        }
    }
}
