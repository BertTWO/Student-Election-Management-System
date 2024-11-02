import React, { useEffect, useState } from 'react';

export default function StudentList() {
  const [students, setStudents] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    fetch('http://localhost:4000/api/Students')
      .then(response => response.json())
      .then(data => setStudents(data))
      .catch(error => console.error('Error fetching students:', error));
  }, []);

  const filteredStudents = students.filter(student =>
    `${student.id}`.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleAddCandidate = (studentId) => {
    console.log(`Adding student with ID ${studentId} as a candidate`);
  };

  return (
    <div className="max-w-6xl mx-auto p-6 bg-gray-50 rounded-lg shadow-md">
      <h2 className="text-3xl font-semibold text-center mb-6 text-gray-800">Student List</h2>
      
      <div className="mb-4 flex justify-end">
        <input
          type="text"
          placeholder="Search ID" 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="p-4 h-2 border rounded shadow"
        />
      </div>

      <table className="w-full table-auto border-collapse bg-white shadow-lg rounded-lg overflow-hidden">
        <thead>
          <tr className="bg-gray-200 text-gray-600 uppercase text-sm leading-normal">
            <th className="py-3 px-4 text-left">ID</th>
            <th className="py-3 px-4 text-left">Name</th>
            <th className="py-3 px-4 text-left">Email</th>
            <th className="py-3 px-4 text-left">Course</th>
            <th className="py-3 px-4 text-left">Year</th>
            <th className="py-3 px-4 text-left">Voter</th>
            <th className="py-3 px-1 text-left">Nominate as Candidate</th>
          </tr>
        </thead>
        <tbody className="text-gray-700 text-sm font-light">
          {filteredStudents.map((student, index) => (
            <tr
              key={student.id}
              className={`border-b ${index % 2 === 0 ? 'bg-gray-100' : 'bg-white'} hover:bg-gray-50 transition duration-150 ease-in-out`}
            >
              <td className="py-3 px-4 font-medium text-gray-900">{student.id}</td>
              <td className="py-3 px-4">{student.firstName} {student.lastName}</td>
              <td className="py-3 px-4">{student.email}</td>
              <td className="py-3 px-4">{student.course}</td>
              <td className="py-3 px-4">{student.year}</td>
              <td className="py-3 px-4">
                <span className={`px-2 py-1 font-semibold rounded-full ${student.isVoter ? 'bg-green-200 text-green-800' : 'bg-red-200 text-red-800'}`}>
                  {student.isVoter ? 'Yes' : 'No'}
                </span>
              </td>
              <td className="py-3 px-4">
                <button
                  onClick={() => handleAddCandidate(student.id)}
                  className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-3 rounded"
                >
                ADD
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
