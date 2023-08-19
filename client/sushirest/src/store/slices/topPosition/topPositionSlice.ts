import {createAsyncThunk, createSlice} from '@reduxjs/toolkit'
import axios from "axios";

export const fetchTopPosSlider = createAsyncThunk(
    'topPosition/fetchTopPosSlider',
    async () => {
        const {data} = await axios.get('https://64c523fec853c26efada8b82.mockapi.io/topPositions')
        return data
    }
)

const initialState = {
    items: [1],

}

export const topPositionSlice = createSlice({
    name: 'topPosition',
    initialState,
    reducers: {
        setItems (state, action){
            state.items = action.payload
        },
    },
    extraReducers: {
        [fetchTopPosSlider.fulfilled]: (state, action) => {
            state.items = action.payload
        }
    }
})

// Action creators are generated for each case reducer function
export const { setItems } = topPositionSlice.actions

export default topPositionSlice.reducer