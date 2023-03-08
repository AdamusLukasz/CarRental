import React, { FormEvent, useState, useEffect } from 'react';
import axios from 'axios';
import { Location } from '../models/location';
import { Car } from '../models/car';
import DatePicker from 'react-datepicker';
import './App.css';
import 'react-datepicker/dist/react-datepicker.css';

function App() {
  const [locations, setLocations] = useState<Location[]>([]);
  const [choosenLocation, setChoosenLocation] = useState<Location | undefined>();
  const [chosenCar, setChosenCar] = useState<Car | undefined>();
  const [startDate, setStartDate] = useState<Date>(new Date());
  const [endDate, setEndDate] = useState<Date>(new Date());

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
    const url = `http://localhost:5000/api/rentals/rentalCar?startDate=${startDate.toISOString()}&endDate=${endDate.toISOString()}&locationId=${choosenLocation.id}&carId=${chosenCar.id}`;
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
          <div>
            <label>Start date:</label>
            <DatePicker selected={startDate} onChange={(date: Date) => setStartDate(date)} />
          </div>
          <div>
            <label>End date:</label>
            <DatePicker selected={endDate} onChange={(date: Date) => setEndDate(date)} />
          </div>
          <div>
            <button type="submit">Rent car</button>
          </div>
        </form>
    </div>
  );
}

export default App;
