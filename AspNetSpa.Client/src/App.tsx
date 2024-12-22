import { useEffect, useState } from "react"

function App() {

  let [val, setVal] = useState<string>('');

  useEffect(() => {
    fetch('/api')
      .then(res => res.text())
      .then(data => setVal(data))
  }, [])

  return (
    <>
      <div style={{ backgroundColor: 'red', color: 'white', fontWeight: 'bold' }}>
        {val}
      </div>
    </>
  )
}

export default App
