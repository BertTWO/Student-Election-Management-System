
import Navbar  from './Components/Navbar';
import StudentList from './Components/Admin/StudentList';
import './App.css'

export default function App() {

  return (
    <>
      <Navbar/>
      <div className='App'>
      <StudentList/>
      </div>
    </>
  )
}

