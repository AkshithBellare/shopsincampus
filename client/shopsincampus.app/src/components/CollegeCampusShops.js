import React, { useState, useEffect } from 'react';

const CampusCollegeShops = () => {
    const [campuses, setCampuses] = useState([]);
    const [colleges, setColleges] = useState([]);
    const [shops, setShops] = useState([]);

    const [selectedCampus, setSelectedCampus] = useState('');
    const [selectedCollege, setSelectedCollege] = useState('');

    // Fetch campuses
    useEffect(() => {
        const fetchCampuses = async () => {
            if (selectedCollege) {
                try {
                    const response = await fetch(`https://shopsincampus-dqerg2dshwhkb0av.westeurope-01.azurewebsites.net/api/Campus/FetchAllCampusesByCollegeId?collegeId=${selectedCollege}`);
                    const data = await response.json();
                    setCampuses(data);
                } catch (error) {
                    console.error('Error fetching campuses:', error);
                }
            }
        };

        fetchCampuses();
    }, [selectedCollege]);

    // Fetch colleges based on selected campus
    useEffect(() => {
        const fetchColleges = async () => {
            try {
                const response = await fetch(`https://shopsincampus-dqerg2dshwhkb0av.westeurope-01.azurewebsites.net/api/College/FetchAllColleges`);
                const data = await response.json();
                setColleges(data);
            } catch (error) {
                console.error('Error fetching colleges:', error);
            }
        };

        fetchColleges();
    }, []);

    // Fetch shops based on selected college and campus
    useEffect(() => {
        const fetchShops = async () => {
            if (selectedCampus && selectedCollege) {
                try {
                    const response = await fetch('https://shopsincampus-dqerg2dshwhkb0av.westeurope-01.azurewebsites.net/api/Shop/FetchAllShopsByCollegeAndCampusId', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                        },
                        body: JSON.stringify({
                            campusId: selectedCampus,
                            collegeId: selectedCollege,
                            // Add any additional data you want to pass here
                        }),
                    });

                    const data = await response.json();
                    setShops(data);
                } catch (error) {
                    console.error('Error fetching shops:', error);
                }
            }
        };

        fetchShops();
    }, [selectedCampus, selectedCollege]);
    return (
        <div>
            <h1>Select College and Campus</h1>
            <div>
                <label htmlFor="college">College:</label>
                <select id="college" value={selectedCollege} onChange={(e) => setSelectedCollege(e.target.value)}>
                    <option value="">Select College</option>
                    {colleges.map((college) => (
                        <option key={college.id} value={college.id}>{college.basicDetails.name}</option>
                    ))}
                </select>
            </div>
            <div>
                <label htmlFor="campus">Campus:</label>
                <select id="campus" value={selectedCampus} onChange={(e) => setSelectedCampus(e.target.value)} disabled={!selectedCollege}>
                    <option value="">Select Campus</option>
                    {campuses.map((campus) => (
                        <option key={campus.id} value={campus.id}>{campus.basicDetails.name}</option>
                    ))}
                </select>
            </div>
            <div>
                <h2>Shops</h2>
                <ul>
                    {shops.map((shop) => (
                        <li key={shop.id}>
                            <strong>{shop.basicDetails.name}</strong>
                            <p>Status: {shop.shopStatus.name}</p>
                            <p>Location: {shop.location}</p>
                        </li>
                    ))}
                </ul>
            </div>
        </div>
    );
};

export default CampusCollegeShops;
