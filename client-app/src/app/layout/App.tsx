import React, { FormEvent, useState, useEffect } from 'react';
import axios from 'axios';
import { Location } from '../models/location';
import { Car } from '../models/car';
import './App.css';

function App() {
  const [locations, setLocations] = useState<Location[]>([]);
  const [choosenLocation, setChoosenLocation] = useState<Location | undefined>();
  const [chosenCar, setChosenCar] = useState<Car | undefined>();

  useEffect(() => {
    axios.get<Location[]>('http://localhost:5000/api/locations')
      .then(response => {
        setLocations(response.data)
      })
  }, [])
  
  function handleLocationChange(event: FormEvent<HTMLSelectElement>) {
    setChoosenLocation(locations.find(location => location.id === Number(event.currentTarget.value)));
    setChosenCar(undefined);
  }

  function handleCarChange(event: FormEvent<HTMLSelectElement>) {
    setChosenCar(choosenLocation?.cars.find(car => car.id === Number(event.currentTarget.value)));
  }

  function handleSubmitRental(event: FormEvent<HTMLFormElement>) {
    event.preventDefault();
    if (!choosenLocation || !chosenCar) {
      return;
    }
    const url = `http://localhost:5000/api/rentals/rentalCar?airportId=${choosenLocation.id}&carId=${chosenCar.id}`;
    axios.post(url)
      .then(response => {
        console.log(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }

  return (
    <div>
      <header>
      <form onSubmit={handleSubmitRental} >
          <div>
            <select onChange={handleLocationChange} className='narrow-dropdown'>
              <option value="">Select location</option>
              {locations.map((location) => (
                <option key={location.id} value={location.id}>
                  {location.name}
                </option>
              ))}
            </select>
          </div>
          {choosenLocation && (
            <div>
              <select onChange={handleCarChange}>
                <option value="">Select car</option>
                {choosenLocation.cars.map((car) => (
                  <option key={car.id} value={car.id}>
                    {car.name}
                  </option>
                ))}
              </select>
            </div>
          )}
        </form>
      </header>
    </div>
  );
}

export default App;
