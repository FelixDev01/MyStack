import { useEffect, useState } from 'react'

interface HardwareItem {
  id: string;
  name: string;
  brand: string;
  price: number;
}

function App() {
  const [items, setItems] = useState<HardwareItem[]>([]);
  const [name, setName] = useState('');
  const [brand, setBrand] = useState('');
  const [price, setPrice] = useState('');

  const fetchItems = () => {
    fetch('http://localhost:8080/api/Hardware')
      .then(res => res.json())
      .then(data => {
        setItems(data);
      });
  };

  useEffect(() => { fetchItems(); }, []); 

  const handleSave = async (e: React.FormEvent) => { 
    e.preventDefault();
    
    const newItem = { name, brand, price: Number(price), isActive: true };

    await fetch('http://localhost:8080/api/Hardware', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(newItem)
    });

    setName(''); setBrand(''); setPrice('');
    fetchItems();
  };

  const handleDelete = async (id: string) => {
    await fetch(`http://localhost:8080/api/Hardware/${id}`, {
      method: 'DELETE'
    });
    fetchItems();
  };

  return (
    <div className="min-h-screen bg-gray-900 text-gray-100 p-8">
      <div className="max-w-2xl mx-auto">
        <h1 className="text-4xl font-bold mb-8 flex items-center gap-3">
            MyStack <span className="text-blue-400 text-lg font-normal">| Hardwares</span>
        </h1>

        <form onSubmit={handleSave} className="bg-gray-800 p-6 rounded-xl border border-gray-700 mb-10 shadow-xl">
          <h2 className="text-xl font-semibold mb-4 text-blue-300">Novo Hardware</h2>
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <input 
              className="bg-gray-900 border border-gray-700 p-2 rounded focus:outline-none focus:border-blue-500"
              placeholder="Nome (ex: RTX 5090)" 
              value={name} onChange={e => setName(e.target.value)} required
            />
            <input 
              className="bg-gray-900 border border-gray-700 p-2 rounded focus:outline-none focus:border-blue-500"
              placeholder="Marca" 
              value={brand} onChange={e => setBrand(e.target.value)} required
            />
            <input 
              className="bg-gray-900 border border-gray-700 p-2 rounded focus:outline-none focus:border-blue-500 md:col-span-2"
              type="number" placeholder="Preço (R$)" 
              value={price} onChange={e => setPrice(e.target.value)} required
            />
            <button className="bg-blue-600 hover:bg-blue-500 text-white font-bold py-2 px-4 rounded transition-colors md:col-span-2">
              Salvar na Stack
            </button>
          </div>
        </form>

        <div className="grid gap-4">
          {items.map((item) => (
            <div key={item.id} className="bg-gray-800 p-4 rounded-lg border border-gray-700 flex justify-between items-center group">
              <div>
                <h3 className="text-lg font-bold text-blue-100">{item.name}</h3>
                <p className="text-sm text-gray-400">{item.brand}</p>
              </div>
              
              <div className="flex items-center gap-6">
                <span className="text-green-400 font-mono font-bold">R$ {item.price.toLocaleString('pt-BR')}</span>
                
                <button 
                  onClick={() => handleDelete(item.id)}
                  className="text-gray-500 hover:text-red-500 transition-colors p-2"
                  title="Deletar"
                >
                  <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                  </svg>
                </button>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  )
}

export default App;