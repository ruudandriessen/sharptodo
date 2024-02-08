import { DeleteIcon } from '@chakra-ui/icons';
import { Checkbox, IconButton, Text } from '@chakra-ui/react';
import styled from '@emotion/styled';

interface TodoProps {
    isChecked: boolean;
    onChange: (isChecked: boolean) => void;
    onDelete: () => void;
    name: string;
}

const FlexRowWrapperEnd = styled.div`
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: end;
    gap: 16px;
    padding: 16px 0;
`;


export const Todo = ({
    isChecked,
    name,
    onChange,
    onDelete,
}: TodoProps) => <FlexRowWrapperEnd>
    <Checkbox 
        colorScheme='green' 
        size={'lg'} 
        isChecked={isChecked}
        onChange={e => onChange(e.target.checked)}>
        <Text 
            fontSize='xl' 
            as='b'
        >
            {name}
        </Text>
    </Checkbox> 
    <IconButton 
        size={'sm'} 
        aria-label='Delete' 
        icon={<DeleteIcon />} 
        onClick={onDelete} 
    />
</FlexRowWrapperEnd>;