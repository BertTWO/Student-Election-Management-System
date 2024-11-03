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
    <div className="max-w-6xl mx-auto my-5 p-6 bg-white rounded-lg shadow-md">
      <h2 className="text-3xl font-semibold text-center mb-5 text-gray-700">STUDENT LIST</h2>
      
      <div className="mb-4 flex justify-end">
        <input
          type="text"
          placeholder="Search ID" 
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="p-4 h-10 border rounded shadow w-1/3"
        />
      </div>

      {/* Adjusted div for consistent scrollbar */}
      <div className="overflow-y-scroll max-h-96 min-h-[400px]">
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
          <tbody className="text-gray-900 text-sm font-light">
            {filteredStudents.map((student, index) => (
              <tr
                key={student.id}
                className={`border-b ${index % 2 === 0 ? 'bg-gray-100' : 'bg-white'} hover:bg-gray-50 transition duration-150 ease-in-out`}
              >
                <td className="py-3 px-4 font-medium text-gray-900">{student.id}</td>
                <td className="py-3 px-4 text-sm">{student.firstName} {student.lastName}</td>
                <td className="py-3 px-4 text-sm">{student.email}</td>
                <td className="py-3 px-4 text-sm">{student.course}</td>
                <td className="py-3 px-4 text-sm">{student.year}</td>
                <td className="py-3 px-4 text-sm">
                  <span className={`px-2 py-1 font-semibold rounded-full ${student.isVoter ? 'bg-green-300 text-green-800 rounded-md px-3' : 'bg-red-200 text-red-800'}`}>
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
    </div>
  );
}
